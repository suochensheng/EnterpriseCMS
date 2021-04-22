package com.vfs.china.afccontractservice.gateway.bjcagatway;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.vfs.china.afccontractservice.config.ApplicationYMLConfig;
import com.vfs.china.afccontractservice.gateway.bjcagatway.model.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.web.client.RestTemplateBuilder;
import org.springframework.http.ResponseEntity;
import org.springframework.http.client.SimpleClientHttpRequestFactory;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;
import javax.annotation.PostConstruct;
import java.net.InetSocketAddress;

@Service
public class BJCAService {
    @Autowired
    private BJCAYMLConfig bjcaYMLConfig;

    @Autowired
    private ApplicationYMLConfig applicationYMLConfig;

    private final RestTemplate restTemplate;

    @PostConstruct
    private void postConstruct() {
        if(bjcaYMLConfig.isIsuseproxy()){
            var proxysetting= applicationYMLConfig.getProxy1();
            String phost= proxysetting.getHost();
            int pport= proxysetting.getPort();
            SimpleClientHttpRequestFactory requestFactory = new SimpleClientHttpRequestFactory();
            java.net.Proxy proxy = new java.net.Proxy(java.net.Proxy.Type.HTTP, new InetSocketAddress(phost, pport));
            requestFactory.setProxy(proxy);
            this.restTemplate.setRequestFactory(requestFactory);
        }
    }

    public BJCAService(RestTemplateBuilder restTemplateBuilder) {
        this.restTemplate = restTemplateBuilder.build();
    }

    public ResponseEntity<BJCAResultDto> signContract(BJCARequestDto bjcaRequest) throws JsonProcessingException{
        String postUrl= bjcaYMLConfig.getInterfaceurl();
        ResponseEntity<BJCAResultDto> res=restTemplate.postForEntity(postUrl,bjcaRequest,BJCAResultDto.class);
        return res;
    }
}
