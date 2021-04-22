package com.vfs.china.afccontractservice;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.netflix.eureka.EnableEurekaClient;

@SpringBootApplication
@EnableEurekaClient
public class AfcContractServiceApplication {
    public static void main(String[] args) {
        SpringApplication.run(AfcContractServiceApplication.class, args);
    }
}
