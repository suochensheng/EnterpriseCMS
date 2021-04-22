package com.vfs.china.afccontractservice.gateway.bjcagatway.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Data;
import java.util.List;

@Data
public class SealsDto {
    //指定印章类型
    @JsonProperty(value = "sealType")
    private String sealType;
    //0 ： 手动拖拽签署；1：使用关键字签署；
    @JsonProperty(value = "signedType")
    private String signedType;
    //signedType 为1时，使用关键字签署，填写签署信息；signedType 为0时，不用填写
    @JsonProperty(value = "signInfo")
    private List<SignInfoDto> signInfo;
}
