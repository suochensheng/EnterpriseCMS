package com.vfs.china.afccontractservice.controller;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.vfs.china.afccontractservice.gateway.bjcagatway.model.BJCAResultDto;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.bind.annotation.*;

import com.vfs.china.afccontractservice.businessmodel.*;
import com.vfs.china.afccontractservice.gateway.bjcagatway.model.*;
import com.vfs.china.afccontractservice.service.*;

@RequestMapping("/contract-callback")
@RestController
@Slf4j
@Configuration
@SuppressWarnings("all")
public class ContractCallbackController {

    @Autowired
    IPMCallBJCAService pmcallbjcaService;

    @Autowired
    IEcBJCAcbiService ecBJCAcbiService;

    /*
    @PostMapping(path ="/contractsignbypm", consumes = "application/json")
    public PMResultDto contractsignbypm(@RequestBody PMMessageInfoDto pmmessageInfo) throws Exception{
        PMResultDto resultDataDto=new PMResultDto();
        try{
            log.info("PM info:"+pmmessageInfo.toString());
            resultDataDto=pmcallbjcaService.getResponseByPMInfo(pmmessageInfo);
        }
        catch(Exception ex)
        {
            resultDataDto.setCode("500");
            resultDataDto.setMessage("API internal error");
            log.error("Get PM Info error:"+ex.getMessage());
        }
        return resultDataDto;
    }

    @RequestMapping(value = "/contractsignbypm1", method = {RequestMethod.GET, RequestMethod.POST})
    @ResponseBody
    public PMResultDto contractsignbypm1(@RequestBody String pmmessageInfoString) throws Exception{
        PMResultDto resultDataDto=new PMResultDto();
        try{
            log.info("PM info:"+pmmessageInfoString);
            ObjectMapper objectMapper = new ObjectMapper();
            var pmmessageInfoDto=objectMapper.readValue(pmmessageInfoString, PMMessageInfoDto.class);
            resultDataDto=pmcallbjcaService.getResponseByPMInfo(pmmessageInfoDto);
        }
        catch(Exception ex)
        {
            resultDataDto.setCode("500");
            resultDataDto.setMessage("API internal error");
            log.error("Get PM Info error:"+ex.getMessage());
        }
        return resultDataDto;
    }
    */
    @PostMapping(path ="/contractsignbybjca1", consumes = "application/json")
    public BJCAResultDto contractsignbybjca1(@RequestBody BJCAcbiDto bjcacbiDto) throws Exception{
        BJCAResultDto resultDataDto=new BJCAResultDto();
        try {
            log.info("BJCA cbi info:"+bjcacbiDto.toString());
            resultDataDto=ecBJCAcbiService.getBJCAcbi(bjcacbiDto);
        }
        catch(Exception ex)
        {
            resultDataDto.setStatusCode("100");
            resultDataDto.setStatusMessage("消息传输异常");
            log.error("Get BJCA Info error:"+ex.getMessage());
        }
        return resultDataDto;
    }

//    @RequestMapping(value = "/contractsignbybjca2", method = {RequestMethod.GET, RequestMethod.POST})
//    @ResponseBody
//    public BJCAResultDto contractsignbybjca2(@RequestBody String bjcacbiDtoString) throws Exception{
//        BJCAResultDto resultDataDto=new BJCAResultDto();
//        try {
//            log.info("BJCA cbi info:"+bjcacbiDtoString);
//            ObjectMapper objectMapper = new ObjectMapper();
//            var bjcacbiDto = objectMapper.readValue(bjcacbiDtoString, BJCAcbiDto.class);
//            resultDataDto=ecBJCAcbiService.getBJCAcbi(bjcacbiDto);
//        }
//        catch(Exception ex)
//        {
//            resultDataDto.setStatusCode("100");
//            resultDataDto.setStatusMessage("消息传输异常");
//            log.error("Get BJCA Info error:"+ex.getMessage());
//        }
//        return resultDataDto;
//    }

}
