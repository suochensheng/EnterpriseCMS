package com.vfs.china.afccontractservice.gateway.bjcagatway.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Data;
import java.util.List;

@Data
public class BJCARequestDto {
    //接入的ID
    @JsonProperty(value = "appId")
    private String appId;
    //发起企业统一信用代码
    @JsonProperty(value = "unCreditCode")
    private String unCreditCode;
    //业务发起人登陆号
    @JsonProperty(value = "creditCode")
    private String creditCode;
    //业务类型描述
    @JsonProperty(value = "businessType")
    private String businessType;
    //合同类型:1征信授权书;2其他类合同;
    @JsonProperty(value = "contractType")
    private String contractType;
    //合同签署截止日期
    @JsonProperty(value = "validityEndDate")
    private String validityEndDate;
    //文档信息
    @JsonProperty(value = "documentInfo")
    private DocumentInfoDto documentInfo;
    //合同签约方信息
    @JsonProperty(value = "subjects")
    private List<SubjectDto> subjects;
    //待签约文件信息
    @JsonProperty(value = "fileInfo")
    private List<FileInfoDto> fileInfo;
    //签约文件附件信息
    @JsonProperty(value = "attachmentInfo")
    private List<AttachmentInfoDto> attachmentInfo;

}
