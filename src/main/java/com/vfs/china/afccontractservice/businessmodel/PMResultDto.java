package com.vfs.china.afccontractservice.businessmodel;
import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Data;

@Data
public class PMResultDto {
    @JsonProperty(value = "code")
    private String code;
    @JsonProperty(value = "message")
    private String message;
}
