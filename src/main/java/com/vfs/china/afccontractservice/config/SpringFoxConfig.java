package com.vfs.china.afccontractservice.config;

import lombok.val;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.bind.annotation.RestController;
import springfox.documentation.builders.ParameterBuilder;
import springfox.documentation.builders.PathSelectors;
import springfox.documentation.builders.RequestHandlerSelectors;
import springfox.documentation.builders.RequestParameterBuilder;
import springfox.documentation.schema.ModelRef;
import springfox.documentation.service.Parameter;
import springfox.documentation.service.ParameterType;
import springfox.documentation.service.RequestParameter;
import springfox.documentation.spi.DocumentationType;
import springfox.documentation.spring.web.plugins.Docket;
import springfox.documentation.swagger2.annotations.EnableSwagger2;

import java.util.Arrays;
import java.util.List;

@EnableSwagger2
@Configuration
public class SpringFoxConfig {
    private List<RequestParameter> globalParameterList() {

        val authTokenHeader =
                new RequestParameterBuilder()
                        .name("Authorization")
                        .required(true).in(ParameterType.HEADER)
                        .description("Basic Auth Token")
                        .build();

        val userNameRequestParameter =
                new RequestParameterBuilder()
                        .name("Authorizationsalesid")
                        .required(true).in(ParameterType.HEADER)
                        .description("salesid VCN id")
                        .build();

        return Arrays.asList(authTokenHeader, userNameRequestParameter);
    }

    @Bean
    public Docket api() {
        //Adding Header

        return new Docket(DocumentationType.SWAGGER_2)
                .forCodeGeneration(true)
                .select()
                .apis(RequestHandlerSelectors.any())
                .paths(PathSelectors.any())
                .build().globalRequestParameters(globalParameterList());
    }
}
