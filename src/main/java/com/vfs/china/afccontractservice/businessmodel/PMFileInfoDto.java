package com.vfs.china.afccontractservice.businessmodel;
import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Data;

@Data
public class PMFileInfoDto {
    @JsonProperty(value = "fileName")
    private String fileName;
    @JsonProperty(value = "fileBase64")
    private String fileBase64;
}
