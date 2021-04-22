package com.vfs.china.afccontractservice.gateway.bjcagatway.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Data;

@Data
public class DocumentInfoDto {
    //文档名称
    @JsonProperty(value = "fileNameDisplay")
    private String fileNameDisplay;
    //文档唯一编号
    @JsonProperty(value = "docId")
    private String docId;
    //处理类别(默认为1)1：顺序处理（按接口中传的签署方的顺序通知及签署）；2：不分先后，可同时签署
    @JsonProperty(value = "processType")
    private String processType;
}
