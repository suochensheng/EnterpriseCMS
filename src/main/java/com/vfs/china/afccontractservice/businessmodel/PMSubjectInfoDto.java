package com.vfs.china.afccontractservice.businessmodel;
import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Data;

@Data
public class PMSubjectInfoDto {
    @JsonProperty(value = "signingRole")
    private String signingRole;
    @JsonProperty(value = "name")
    private String name;
    @JsonProperty(value = "isCorporate")
    private String isCorporate;
    @JsonProperty(value = "creditCode")
    private String creditCode;
    @JsonProperty(value = "mobile")
    private String mobile;
    @JsonProperty(value = "email")
    private String email;
}
