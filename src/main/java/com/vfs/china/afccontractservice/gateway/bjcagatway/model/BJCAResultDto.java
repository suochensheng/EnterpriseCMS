package com.vfs.china.afccontractservice.gateway.bjcagatway.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Data;

@Data
public class BJCAResultDto {
    //返回码
    @JsonProperty(value = "statusCode")
    private String statusCode;
    //细节说明
    @JsonProperty(value = "statusMessage")
    private String statusMessage;
}
