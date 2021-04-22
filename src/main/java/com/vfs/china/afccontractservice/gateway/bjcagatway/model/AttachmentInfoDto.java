package com.vfs.china.afccontractservice.gateway.bjcagatway.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Data;
import java.util.List;

@Data
public class AttachmentInfoDto {
    //附件名称
    @JsonProperty(value = "fileName")
    private String fileName;
    //附件传输参数
    @JsonProperty(value = "downloadParam")
    private AttachFileDownloadParamDto downloadParam;
}
