package com.vfs.china.afccontractservice.controller;

import com.fasterxml.jackson.databind.ObjectMapper;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.bind.annotation.*;

import com.vfs.china.afccontractservice.businessmodel.*;
import com.vfs.china.afccontractservice.service.IPMCallBJCAService;

@RequestMapping("/contract-sign")
@RestController
@Slf4j
@Configuration
@SuppressWarnings("all")
public class ContractServiceController {

    @Autowired
    IPMCallBJCAService pmcallbjcaService;

//    @PostMapping(path ="/contractsignbypm", consumes = "application/json")
//    public PMResultDto contractsignbypm(@RequestBody PMMessageInfoDto pmmessageInfo) throws Exception{
//        PMResultDto resultDataDto=new PMResultDto();
//        try{
//            //log.info("PM info:"+pmmessageInfo.toString());
//            resultDataDto=pmcallbjcaService.getResponseByPMInfo(pmmessageInfo);
//        }
//        catch(Exception ex)
//        {
//            resultDataDto.setCode("500");
//            resultDataDto.setMessage("API internal error");
//            log.error("contractsignbypm function error:"+ex.getMessage());
//        }
//        return resultDataDto;
//    }

    @RequestMapping(value = "/contractsignbypm1", method = {RequestMethod.GET, RequestMethod.POST})
    @ResponseBody
    public PMResultDto contractsignbypm1(@RequestBody String pmmessageInfoString) throws Exception{
        PMResultDto resultDataDto=new PMResultDto();
        try{
            log.info("PM info:"+pmmessageInfoString);
            ObjectMapper objectMapper = new ObjectMapper();
            var pmmessageInfoDto=objectMapper.readValue(pmmessageInfoString, PMMessageInfoDto.class);
            resultDataDto=pmcallbjcaService.sendPmQuotationToBjca(pmmessageInfoDto);
        }
        catch(Exception ex)
        {
            resultDataDto.setCode("500");
            resultDataDto.setMessage("API internal error:"+ex.getMessage());
            log.error("contractsignbypm1 function error:"+ex.getMessage());
        }
        return resultDataDto;
    }
}
