package com.vfs.china.afccontractservice.gateway.bjcagatway.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Data;

@Data
public class BJCAcbiSubjectDto {
    //签约人、企业名称
    @JsonProperty(value = "name")
    public String name;
    //签约方:1 企业法人;2 自然人;
    @JsonProperty(value = "type")
    public String type;
    //签约方证件号码:企业统一信用代码、自然人身份证号
    @JsonProperty(value = "creditCode")
    public String creditCode;
    //签署方签署状态:0 待他人处理;1 待处理;2 签署中;3 已完成;
    @JsonProperty(value = "status")
    public String status;

}
