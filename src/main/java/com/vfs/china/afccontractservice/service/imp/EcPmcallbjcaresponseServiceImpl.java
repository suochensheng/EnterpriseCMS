package com.vfs.china.afccontractservice.service.imp;

import java.util.List;

import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.vfs.china.afccontractservice.repository.EcPmcallbjcaresponseRep;
import com.vfs.china.afccontractservice.service.IEcPmcallbjcaresponseService;
import com.vfs.china.afccontractservice.entity.EcPmquotactionResponseEntity;

@Slf4j
@Service
public class EcPmcallbjcaresponseServiceImpl implements IEcPmcallbjcaresponseService{
    @Autowired
    private EcPmcallbjcaresponseRep ecPmcallbjcaresponseRep;

    @Override
    public EcPmquotactionResponseEntity getPmquotactionResponseByAssociationid(String associationid){
        EcPmquotactionResponseEntity ecPmcallbjcaresponseobj=new EcPmquotactionResponseEntity();
        List<EcPmquotactionResponseEntity> ecPmcallbjcaresponselist=ecPmcallbjcaresponseRep.findAllByAssociationid(associationid);
        if(ecPmcallbjcaresponselist.size()>0)
        {
            ecPmcallbjcaresponseobj=ecPmcallbjcaresponselist.get(0);
        }
        else
        {
            ecPmcallbjcaresponseobj.setId(0);
        }
        return ecPmcallbjcaresponseobj;
    }
}
