package com.vfs.china.afccontractservice.gateway.bjcagatway.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Data;
import java.util.List;

@Data
public class SubjectDto {
    //签约方：1 企业法人；2 自然人；
    @JsonProperty(value = "type")
    private String type;
    //签约方名称：企业名称或自然人姓名
    @JsonProperty(value = "name")
    private String name;
    //签约方证件号码：企业统一信用代码、自然人身份证号；
    @JsonProperty(value = "creditCode")
    private String creditCode;
    //印章列表
    @JsonProperty(value = "seals")
    private List<SealsDto> seals;
    //签约方经办人信息
    @JsonProperty(value = "operatorInfo")
    private List<OperatorInfoDto> operatorInfo;
}
