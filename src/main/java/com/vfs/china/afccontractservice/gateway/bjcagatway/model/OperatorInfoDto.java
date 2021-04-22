package com.vfs.china.afccontractservice.gateway.bjcagatway.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Data;

@Data
public class OperatorInfoDto {
    //手机号
    @JsonProperty(value = "mobileNumber")
    private String mobileNumber;
    //姓名
    @JsonProperty(value = "name")
    private String name;
    //邮箱
    @JsonProperty(value = "email")
    private String email;
}
