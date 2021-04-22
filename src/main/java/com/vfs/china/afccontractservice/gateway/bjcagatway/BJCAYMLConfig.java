package com.vfs.china.afccontractservice.gateway.bjcagatway;

import lombok.Data;
import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.stereotype.Component;

@Data
@Component
@ConfigurationProperties(prefix = "bjcaconfig")
public class BJCAYMLConfig {
    private String appid;
    private String uncreditcode;
    private String templateType;
    private String templateId;
    private String personSignsType;
    private String personSignsRole;
    private String personSignsCardType;
    private String enterpriseSignsType;
    private String enterpriseSignsEnterpriseName;
    private String enterpriseSignsRole;
    private String businessType;
    private boolean isuseproxy;
    private String keyword;
    private String interfaceurl;
}
