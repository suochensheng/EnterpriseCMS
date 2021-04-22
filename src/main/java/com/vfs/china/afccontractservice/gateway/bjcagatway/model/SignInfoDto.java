package com.vfs.china.afccontractservice.gateway.bjcagatway.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Data;

@Data
public class SignInfoDto {
    //印章签署位置的定位关键字
    @JsonProperty(value = "keyword")
    private String keyword;
    //关键字类型：0 为所有关键字；1 为单个关键字（最后一个）,默认为单个关键字
    @JsonProperty(value = "keywordType")
    private String keywordType;
//    //印章覆盖类型，覆盖类型，1：重叠；2：居下；3：居右,关键字定位时必填
//    @JsonProperty(value = "coverType")
//    private String coverType;
//    //关键字定位后宽度偏移（整数）
//    @JsonProperty(value = "widthMoveSize")
//    private Integer widthMoveSize;
//    //关键字定位后高度偏移（整数）
//    @JsonProperty(value = "heightMoveSize")
//    private Integer heightMoveSize;
}
