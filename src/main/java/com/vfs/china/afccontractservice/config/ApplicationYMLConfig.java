package com.vfs.china.afccontractservice.config;

import lombok.Data;
import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.stereotype.Component;

@Data
@Component
@ConfigurationProperties(prefix = "appconfig")
public class ApplicationYMLConfig {

    private String name;
    private String pwd;

    private String businessmodel;

    private Proxy1 proxy1;
    private Proxy2 proxy2;
    private Proxy3 proxy3;

    @Data
    public static class Proxy1{
        private String host;
        private int port;
        private String domain;
        private String username;
        private String password;
    }
    @Data
    public static class Proxy2{
        private String host;
        private int port;
        private String domain;
        private String username;
        private String password;
    }
    @Data
    public static class Proxy3{
        private String host;
        private int port;
        private String domain;
        private String username;
        private String password;
    }
}
