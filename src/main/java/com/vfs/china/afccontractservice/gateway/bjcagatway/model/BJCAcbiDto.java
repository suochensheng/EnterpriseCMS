package com.vfs.china.afccontractservice.gateway.bjcagatway.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Data;
import java.util.List;

@Data
public class BJCAcbiDto {
    //文档唯一编号
    @JsonProperty(value = "docId")
    public String docId;
    //合同文件名称
    @JsonProperty(value = "fileName")
    public String fileName;
    //文件下载地址:本地路径或NAS 路径
    @JsonProperty(value = "filePath")
    public String filePath;
    //文件签署或状态最后更新时间
    @JsonProperty(value = "operateTime")
    public String operateTime;
    //合同签署状态:1 代表未签署、2 代表签署中、3代表已签署、4 代表已撤销、5代表已冻结、6 代表已过期;
    @JsonProperty(value = "signStatus")
    public String signStatus;
    //签约方状态信息
    @JsonProperty(value = "subjects")
    public List<BJCAcbiSubjectDto> subjects;
}
