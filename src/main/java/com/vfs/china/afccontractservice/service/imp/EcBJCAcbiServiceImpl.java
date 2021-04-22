package com.vfs.china.afccontractservice.service.imp;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.vfs.china.afccontractservice.service.IEcPmcallbjcaresponseService;
import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Service;
import org.springframework.beans.factory.annotation.Autowired;

import java.sql.Timestamp;
import java.util.Date;

import com.vfs.china.afccontractservice.entity.*;
import com.vfs.china.afccontractservice.gateway.bjcagatway.model.*;
import com.vfs.china.afccontractservice.repository.EcBJCAcbiRep;
import com.vfs.china.afccontractservice.repository.EcPmcallbjcaresponseRep;
import com.vfs.china.afccontractservice.service.IEcBJCAcbiService;

@Slf4j
@Service
public class EcBJCAcbiServiceImpl implements IEcBJCAcbiService{
    @Autowired
    EcBJCAcbiRep ecBJCAcbiRepository;

    @Autowired
    EcPmcallbjcaresponseRep ecPmcallbjcaresponseRep;

    @Autowired
    IEcPmcallbjcaresponseService ecPmcallbjcaresponseService;

    @Override
    public BJCAResultDto getBJCAcbi(BJCAcbiDto bjcacbi)
    {
        BJCAResultDto resultDataDto=new BJCAResultDto();

        try{
            //save BJCAcbi info
            EcBJCAcbiEntity ecBJCAcbi=GetEcBJCAcbiInfo(bjcacbi);
            SaveBJCAcbiInfo(ecBJCAcbi);

            EcPmquotactionResponseEntity pmobj=ecPmcallbjcaresponseService.getPmquotactionResponseByAssociationid(bjcacbi.getDocId());
            int id=pmobj.getId();
            if(id!=0)
            {
                pmobj.setBjcaDownloadpath(bjcacbi.getFilePath());
                pmobj.setBjcaContractactivestatuscode(bjcacbi.getSignStatus());
                ObjectMapper objectMapper = new ObjectMapper();
                String requestStr = objectMapper.writeValueAsString(bjcacbi);
                pmobj.setBjcaResponsemessage(requestStr);
                ecPmcallbjcaresponseRep.save(pmobj);



                resultDataDto.setStatusCode("200");
                resultDataDto.setStatusMessage("成功");
                log.info("docNum:"+bjcacbi.getDocId()+", 业务处理成功");
            }
            else
            {
                resultDataDto.setStatusCode("101");
                resultDataDto.setStatusMessage("业务不存在");
                log.info("docNum:"+bjcacbi.getDocId()+", 业务不存在");
            }


        }
        catch(Exception ex)
        {
            resultDataDto.setStatusCode("100");
            resultDataDto.setStatusMessage("处理业务失败");
            log.error("Get BJCAcbi Info error:"+ex.getMessage());
        }

        return resultDataDto;
    }

    //Set EcBJCAcbi
    private EcBJCAcbiEntity GetEcBJCAcbiInfo(BJCAcbiDto bjcacbi) throws JsonProcessingException
    {
        EcBJCAcbiEntity ecBJCAcbi=new EcBJCAcbiEntity();
        Date date=new Date();
        ecBJCAcbi.setDocnum(bjcacbi.getDocId());
        ObjectMapper objectMapper = new ObjectMapper();
        String requestStr = objectMapper.writeValueAsString(bjcacbi);
        ecBJCAcbi.setResponsecontent(requestStr);
        Timestamp createTime = new Timestamp(date.getTime());
        ecBJCAcbi.setCreationtime(createTime);
        return ecBJCAcbi;
    }

    //Save BJCAcbi Info
    private void SaveBJCAcbiInfo(EcBJCAcbiEntity ecBJCAcbi)
    {
        ecBJCAcbiRepository.save(ecBJCAcbi);
    }
}
