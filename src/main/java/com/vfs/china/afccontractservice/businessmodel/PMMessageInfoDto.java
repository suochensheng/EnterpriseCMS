package com.vfs.china.afccontractservice.businessmodel;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.vfs.china.afccontractservice.businessmodel.PMSubjectInfoDto;
import com.vfs.china.afccontractservice.businessmodel.PMFileInfoDto;
import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;


@Data
@NoArgsConstructor
@JsonIgnoreProperties(ignoreUnknown = true)
public class PMMessageInfoDto {
    @JsonProperty(value = "creditCode")
    private String creditCode;
    @JsonProperty(value = "docName")
    private String docName;
    @JsonProperty(value = "docId")
    private String docId;
    @JsonProperty(value = "subjects")
    private List<PMSubjectInfoDto> subjects;
    @JsonProperty(value = "fileInfo")
    private List<PMFileInfoDto> fileInfo;
}
