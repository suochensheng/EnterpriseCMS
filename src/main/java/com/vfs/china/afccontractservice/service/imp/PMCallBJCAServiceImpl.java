package com.vfs.china.afccontractservice.service.imp;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import lombok.extern.slf4j.Slf4j;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.beans.factory.annotation.Autowired;

import java.sql.Timestamp;
import java.text.SimpleDateFormat;
import java.util.*;
import java.util.stream.Collectors;

import com.vfs.china.afccontractservice.service.IPMCallBJCAService;
import com.vfs.china.afccontractservice.businessmodel.*;
import com.vfs.china.afccontractservice.gateway.bjcagatway.model.*;
import com.vfs.china.afccontractservice.gateway.bjcagatway.BJCAService;
import com.vfs.china.afccontractservice.gateway.bjcagatway.BJCAYMLConfig;
import com.vfs.china.afccontractservice.entity.*;
import com.vfs.china.afccontractservice.repository.*;

@Slf4j
@Service
public class PMCallBJCAServiceImpl implements IPMCallBJCAService{

    @Autowired
    private BJCAService bjcaService;

    @Autowired
    private BJCAYMLConfig bjcaYMLConfig;

    @Autowired
    private EcPmquotactionRequestRep ecpmquotactionRequestRep;

    @Autowired
    private EcPmquotactionRequestSubjectsRep ecpmquotactionRequestSubjectsRep;

    @Autowired
    private EcPmcallbjcaresponseRep ecpmcallbjcaresponseRep;

    @Override
    public PMResultDto sendPmQuotationToBjca(PMMessageInfoDto pmmessageInfo)
    {
        PMResultDto resultDataDto=new PMResultDto();
        ResponseEntity<BJCAResultDto> bjcaResult=null;

        String associationid= UUID.randomUUID().toString().replace("-", "");
        //Save PMmessage OBJ
        int pmrequestid=SavePMRequestMessage(associationid,pmmessageInfo);
        BJCARequestDto bjcaRequestobj=null;

        try
        {
            log.info("Start BJCA Sign Request");
            bjcaRequestobj=prepareBjcaContractSignRequest(pmmessageInfo,associationid);
            bjcaResult= bjcaService.signContract(bjcaRequestobj);
            resultDataDto.setCode(bjcaResult.getBody().getStatusCode());
            if(bjcaResult.getBody().getStatusCode().equals("200"))
            {
                resultDataDto.setMessage("Succes");
            }
            else
            {
                resultDataDto.setMessage(bjcaResult.getBody().getStatusMessage());
            }
            log.info("End BJCA Sign Request");
        }
        catch(Exception e)
        {
            resultDataDto.setCode("500");
            resultDataDto.setMessage("API internal error");
            log.error("PM message sent to BJCA api error:"+e.getMessage());
        }
        log.info("Start DBSave EcPmcallbjcaresponse");
        //Save EcPmcallbjcaresponse to database
        SaveEcPmcallbjcaresponse(pmmessageInfo.getCreditCode(), pmmessageInfo.getDocId(),associationid,pmrequestid,bjcaRequestobj,bjcaResult,resultDataDto);
        log.info("End DBSave EcPmcallbjcaresponse");
        return resultDataDto;
    }

    //Set Request Json for BJCA
    private BJCARequestDto prepareBjcaContractSignRequest(PMMessageInfoDto pmmessageInfo,String associateId) throws JsonProcessingException {
        BJCARequestDto bjcaRequestOBJ=new BJCARequestDto();

        bjcaRequestOBJ.setAppId(bjcaYMLConfig.getAppid());
        bjcaRequestOBJ.setUnCreditCode(bjcaYMLConfig.getUncreditcode());
        bjcaRequestOBJ.setCreditCode(pmmessageInfo.getCreditCode());
        bjcaRequestOBJ.setBusinessType(bjcaYMLConfig.getBusinessType());
        bjcaRequestOBJ.setContractType("2");
        bjcaRequestOBJ.setValidityEndDate(GetvalidityEndDate()+" 23:59:59");

        //documentInfo
        DocumentInfoDto documentinfo=new DocumentInfoDto();
        documentinfo.setFileNameDisplay(pmmessageInfo.getDocName());
       // documentinfo.setDocId(pmmessageInfo.getDocId());
        //change docid to associate id when send to BJCA, because quotation id is not unique id from PM system.
        documentinfo.setDocId(associateId);
        documentinfo.setProcessType("2");
        bjcaRequestOBJ.setDocumentInfo(documentinfo);

        //subjects
        List<SubjectDto> subjectsList=new ArrayList<SubjectDto>();
        for(PMSubjectInfoDto subjectinfo : pmmessageInfo.getSubjects())
        {
            if(subjectinfo.getSigningRole().equals("0") || subjectinfo.getSigningRole().equals("1") || subjectinfo.getSigningRole().equals("2") || subjectinfo.getSigningRole().equals("4") || subjectinfo.getSigningRole().equals("7") || subjectinfo.getSigningRole().equals("9") || subjectinfo.getSigningRole().equals("12"))
            {
                SubjectDto subject=new SubjectDto();

                //0=Corporate;1=Individual
                if(subjectinfo.getIsCorporate().equals("0"))
                {
                    //自然人
                    subject.setType("2");
                }
                else
                {
                    //企业法人
                    subject.setType("1");
                }

                //签约方名称
                subject.setName(subjectinfo.getName());

                //签约方证件号码
                subject.setCreditCode(subjectinfo.getCreditCode());

                //VFS
                if(subjectinfo.getSigningRole().equals("4"))
                {
                    subject.setName(bjcaYMLConfig.getEnterpriseSignsEnterpriseName());
                    subject.setCreditCode(bjcaYMLConfig.getUncreditcode());
                    subject.setType("1");
                }

                //印章列表
                List<SealsDto> sealsList=new ArrayList<SealsDto>();
                SealsDto sealsInfo=new SealsDto();
                sealsInfo.setSealType("1");
                sealsInfo.setSignedType("1");
                List<SignInfoDto> signInfoList=new ArrayList<SignInfoDto>();
                SignInfoDto signInfo=new SignInfoDto();
                signInfo.setKeyword(keywordStr(subjectinfo.getSigningRole()));
                signInfo.setKeywordType("1");
//                signInfo.setCoverType("3");
//                signInfo.setWidthMoveSize(0);
//                signInfo.setHeightMoveSize(0);
                signInfoList.add(signInfo);
                sealsInfo.setSignInfo(signInfoList);
                sealsList.add(sealsInfo);
                subject.setSeals(sealsList);

                //签约方经办人信息
                List<OperatorInfoDto> operatorInfoList=new ArrayList<OperatorInfoDto>();

                List<PMSubjectInfoDto> subjectlist=new ArrayList<PMSubjectInfoDto>();

                //Customer
                if(subjectinfo.getSigningRole().equals("0"))
                {
                    //CustomerContact
                    subjectlist=pmmessageInfo.getSubjects().stream().filter(s->s.getSigningRole().equals("8")).collect(Collectors.toList());
                }
                //Guarantor
                if(subjectinfo.getSigningRole().equals("2"))
                {
                    //GuarantorContact
                    subjectlist=pmmessageInfo.getSubjects().stream().filter(s->s.getSigningRole().equals("10")).collect(Collectors.toList());
                }
                //Dealer
                if(subjectinfo.getSigningRole().equals("1"))
                {
                    //DealerContact
                    subjectlist=pmmessageInfo.getSubjects().stream().filter(s->s.getSigningRole().equals("11")).collect(Collectors.toList());
                }
                //Supplier
                if(subjectinfo.getSigningRole().equals("12"))
                {
                    //SupplierContact
                    subjectlist=pmmessageInfo.getSubjects().stream().filter(s->s.getSigningRole().equals("13")).collect(Collectors.toList());
                }

                if(subjectlist.size()>0) {
                    for(PMSubjectInfoDto subobj : subjectlist) {
                        OperatorInfoDto operatorInfo = new OperatorInfoDto();
                        operatorInfo.setMobileNumber(subobj.getMobile());
                        operatorInfo.setName(subobj.getName());
                        operatorInfo.setEmail(subobj.getEmail());
                        operatorInfoList.add(operatorInfo);
                    }
                }
                subject.setOperatorInfo(operatorInfoList);

                subjectsList.add(subject);
            }
        }
        bjcaRequestOBJ.setSubjects(subjectsList);

        //fileInfo
        List<FileInfoDto> fileInfoList=new ArrayList<FileInfoDto>();
        for(PMFileInfoDto pmFileInfo : pmmessageInfo.getFileInfo())
        {
            FileInfoDto fileinfo=new FileInfoDto();
            fileinfo.setFileName(pmFileInfo.getFileName());
            DownloadParamDto downloadParamInfo=new DownloadParamDto();
            downloadParamInfo.setDownLoadType("1");
            downloadParamInfo.setFileDownloadAddress("");
            downloadParamInfo.setDocumentId("");
            downloadParamInfo.setFileBase64(pmFileInfo.getFileBase64());
            downloadParamInfo.setFileExtensionName(GetFileTypeName(pmFileInfo.getFileName()));
            fileinfo.setDownloadParam(downloadParamInfo);
            fileInfoList.add(fileinfo);
        }
        bjcaRequestOBJ.setFileInfo(fileInfoList);

        //attachmentInfo
        List<AttachmentInfoDto> attachmentInfoList=new ArrayList<AttachmentInfoDto>();
        bjcaRequestOBJ.setAttachmentInfo(attachmentInfoList);

        ObjectMapper objectMapper = new ObjectMapper();
        String requestStr = objectMapper.writeValueAsString(bjcaRequestOBJ);
        //log.info("BJCARequestDto info:"+requestStr);

        return bjcaRequestOBJ;
    }

    //Get validityEndDate
    private String GetvalidityEndDate()
    {
        SimpleDateFormat sf = new SimpleDateFormat("yyyy-MM-dd");
        Calendar c = Calendar.getInstance();
        c.add(Calendar.DAY_OF_MONTH, 16);
        return sf.format(c.getTime());
    }

    //Get File Type Name
    private String GetFileTypeName(String filename)
    {
        int index = filename.lastIndexOf(".");
        if (index == -1) {
            return "";
        }
        return filename.substring(index + 1);
    }

    //Save PMmessage Info
    private int SavePMRequestMessage (String associationid,PMMessageInfoDto pmmessageOBJ)
    {
        int requestid=0;
        try
        {
            EcPmquotactionRequestEntity ecpmmessageobj=new EcPmquotactionRequestEntity();
            ObjectMapper objectMapper = new ObjectMapper();
            String reponseStr = objectMapper.writeValueAsString(pmmessageOBJ);
            //log.info("PM reponse info:"+reponseStr);
            ecpmmessageobj.setRequestmessage(reponseStr);
            ecpmmessageobj.setDocid(pmmessageOBJ.getDocId());
            ecpmmessageobj.setAssociationid(associationid);
            Boolean Isneedvfssign=pmmessageOBJ.getSubjects().stream().anyMatch(singnrole->singnrole.getSigningRole().equals("4"));
            if(Isneedvfssign)
            {
                ecpmmessageobj.setIsneedvfssign("Y");
            }
            else
            {
                ecpmmessageobj.setIsneedvfssign("N");
            }
            ecpmmessageobj.setTotalsignstatus("Pending");
            Date date = new Date();
            Timestamp createTime = new Timestamp(date.getTime());
            ecpmmessageobj.setCreationtime(createTime);
            var pmobj=ecpmquotactionRequestRep.save(ecpmmessageobj);
            requestid=pmobj.getId();

            //Save Subjects
            SaveEcPmquotactionRequestSubjects(requestid,associationid,pmmessageOBJ);
        }
        catch (JsonProcessingException e) {
            log.error("PMMessageInfoDto to string error:"+e.getMessage());
        }
        catch(Exception ex)
        {
            log.error("Save PMmessage error:"+ex.getMessage());
        }
        return requestid;
    }

    //Save PM call BJCA Reponse
    private void SaveEcPmcallbjcaresponse(String Creditcode, String quotationid, String associationid,int pmrequestid,BJCARequestDto bjcaRequestOBJ,ResponseEntity<BJCAResultDto> bjcaResultOBJ,PMResultDto resultDataDto)
    {
        try
        {
            EcPmquotactionResponseEntity ecPmcallbjcaresponseobj=new EcPmquotactionResponseEntity();
            ObjectMapper objectMapper = new ObjectMapper();
            String requestStr = objectMapper.writeValueAsString(bjcaRequestOBJ);
            ecPmcallbjcaresponseobj.setPmquotactionRequestid(pmrequestid);
            ecPmcallbjcaresponseobj.setBjcaRequestmessage(requestStr);
            ecPmcallbjcaresponseobj.setBjcaResponsecode(bjcaResultOBJ.getBody().getStatusCode());
            ecPmcallbjcaresponseobj.setBjcaResponsemessage(bjcaResultOBJ.getBody().getStatusMessage());
            ecPmcallbjcaresponseobj.setPmResponsecode(resultDataDto.getCode());
            String pmresultmessage = objectMapper.writeValueAsString(resultDataDto);
            ecPmcallbjcaresponseobj.setPmResponsemessage(pmresultmessage);
            ecPmcallbjcaresponseobj.setAssociationid(associationid);
            Date date = new Date();
            Timestamp createTime = new Timestamp(date.getTime());
            ecPmcallbjcaresponseobj.setCreationtime(createTime);
            ecPmcallbjcaresponseobj.setCreditcode(Creditcode);
            ecPmcallbjcaresponseobj.setQuotationnum(quotationid);

            ecPmcallbjcaresponseobj.setContractactivestatus("0");
            ecpmcallbjcaresponseRep.save(ecPmcallbjcaresponseobj);
        }
        catch(JsonProcessingException e)
        {
            log.error("bjcaRequestOBJ to string error:"+e.getMessage());
        }
        catch(Exception ex)
        {
            log.error("Save EcPmcallbjcaresponse error:"+ex.getMessage());
        }
    }

    private String keywordStr(String rolecode)
    {
        String keyword="";
        switch(rolecode)
        {
            case "0":keyword="承租人：";break;
            case "1":keyword="供应商";break;
            case "2":keyword="保证人：";break;
            case "4":keyword="沃尔沃汽车金融（中国）有限公司";break;
            case "7":keyword="承租人配偶";break;
            case "9":keyword="保证人配偶";break;
            case "12":keyword="运输公司";break;
            default:keyword=bjcaYMLConfig.getKeyword();
        }
        return keyword;
    }

    //Save EcPmquotactionRequestSubjects object
    private void SaveEcPmquotactionRequestSubjects(int requestid,String associationid,PMMessageInfoDto pmmessageOBJ)
    {
        try
        {
            List<EcPmquotactionRequestSubjectsEntity> ecPmquotactionRequestSubjectsList=new ArrayList<EcPmquotactionRequestSubjectsEntity>();
            for(PMSubjectInfoDto pmSubjectInfo : pmmessageOBJ.getSubjects())
            {
                EcPmquotactionRequestSubjectsEntity ecPmquotactionRequestSubjectsObj=new EcPmquotactionRequestSubjectsEntity();
                ecPmquotactionRequestSubjectsObj.setRequestId(requestid);
                ecPmquotactionRequestSubjectsObj.setAssociationid(associationid);
                ecPmquotactionRequestSubjectsObj.setSigningRole(pmSubjectInfo.getSigningRole());
                if(pmSubjectInfo.getSigningRole().equals("4"))
                {
                    ecPmquotactionRequestSubjectsObj.setName(bjcaYMLConfig.getEnterpriseSignsEnterpriseName());
                    ecPmquotactionRequestSubjectsObj.setCreditCode(bjcaYMLConfig.getUncreditcode());
                    ecPmquotactionRequestSubjectsObj.setType("1");
                }
                else
                {
                    ecPmquotactionRequestSubjectsObj.setName(pmSubjectInfo.getName());
                    ecPmquotactionRequestSubjectsObj.setCreditCode(pmSubjectInfo.getCreditCode());
                    ecPmquotactionRequestSubjectsObj.setType(pmSubjectInfo.getIsCorporate());
                }

                ecPmquotactionRequestSubjectsObj.setStatus("Pending");


                ecPmquotactionRequestSubjectsList.add(ecPmquotactionRequestSubjectsObj);
            }

            ecpmquotactionRequestSubjectsRep.saveAll(ecPmquotactionRequestSubjectsList);
        }
        catch(Exception ex)
        {
            log.error("Save EcpmquotactionRequestSubjects error:"+ex.getMessage());
        }
    }
}
