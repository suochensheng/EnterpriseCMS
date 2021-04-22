package com.vfs.china.afccontractservice.gateway.bjcagatway.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Data;

@Data
public class AttachFileDownloadParamDto {
    //附件传输类型：1、Base64；2 、本地路径或NAS（推荐）；3、HTTP URL；4、FTP；5、云盘
    @JsonProperty(value = "downLoadType")
    private String downLoadType;
    //文件获取地址：对应type 中的2、3、4
    @JsonProperty(value = "fileDownloadAddress")
    private String fileDownloadAddress;
    //文件云盘ID 对应type 中的5
    @JsonProperty(value = "documentId")
    private String documentId;
    //文件(Base64) 内容，对应type 中的1
    @JsonProperty(value = "fileBase64")
    private String fileBase64;
    //文件类型，支持doc、docx、pdf；
    @JsonProperty(value = "fileExtensionName")
    private String fileExtensionName;
}
