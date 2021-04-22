package com.vfs.china.afccontractservice.repository;

import com.vfs.china.afccontractservice.entity.EcPmquotactionResponseEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import java.util.List;

public interface EcPmcallbjcaresponseRep extends JpaRepository<EcPmquotactionResponseEntity,Integer>{

    @Query(value="select * from ec_pmquotaction_response where contractnumber= :contractnumber ",nativeQuery = true)
    List<EcPmquotactionResponseEntity> findAllByContractnumber(@org.springframework.data.repository.query.Param("contractnumber") String Contractnumber);

    @Query(value="select * from ec_pmquotaction_response where Associationid= :associationid ",nativeQuery = true)
    List<EcPmquotactionResponseEntity> findAllByAssociationid(@org.springframework.data.repository.query.Param("associationid") String associationid);

}
