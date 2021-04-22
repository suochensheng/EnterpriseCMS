package com.vfs.china.afccontractservice.entity;

import javax.persistence.*;
import java.sql.Timestamp;
import java.util.Objects;

@Entity
@Table(name = "ec_pmquotaction_request", schema = "csg_esign", catalog = "")
public class EcPmquotactionRequestEntity {
    private int id;
    private String requestmessage;
    private String docid;
    private String associationid;
    private Timestamp creationtime;
    private String isneedvfssign;
    private String totalsignstatus;
    private String contractNum;
    private String cmsContractActiveStatus;

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    @Basic
    @Column(name = "requestmessage", nullable = true, length = -1)
    public String getRequestmessage() {
        return requestmessage;
    }

    public void setRequestmessage(String requestmessage) {
        this.requestmessage = requestmessage;
    }

    @Basic
    @Column(name = "docid", nullable = true, length = 100)
    public String getDocid() {
        return docid;
    }

    public void setDocid(String docid) {
        this.docid = docid;
    }

    @Basic
    @Column(name = "associationid", nullable = true, length = 100)
    public String getAssociationid() {
        return associationid;
    }

    public void setAssociationid(String associationid) {
        this.associationid = associationid;
    }

    @Basic
    @Column(name = "creationtime", nullable = true)
    public Timestamp getCreationtime() {
        return creationtime;
    }

    public void setCreationtime(Timestamp creationtime) {
        this.creationtime = creationtime;
    }

    @Basic
    @Column(name = "isneedvfssign", nullable = true, length = 45)
    public String getIsneedvfssign() {
        return isneedvfssign;
    }

    public void setIsneedvfssign(String isneedvfssign) {
        this.isneedvfssign = isneedvfssign;
    }

    @Basic
    @Column(name = "totalsignstatus", nullable = true, length = 45)
    public String getTotalsignstatus() {
        return totalsignstatus;
    }

    public void setTotalsignstatus(String totalsignstatus) {
        this.totalsignstatus = totalsignstatus;
    }

    @Basic
    @Column(name = "contractnum", nullable = true, length = 250)
    public String getContractNum() {
        return contractNum;
    }

    public void setContractNum(String contractNum) {
        this.contractNum = contractNum;
    }

    @Basic
    @Column(name = "cmscontractactivestatus", nullable = true, length = 45)
    public String getCmsContractActiveStatus() {
        return cmsContractActiveStatus;
    }

    public void setCmsContractActiveStatus(String cmsContractActiveStatus) {
        this.cmsContractActiveStatus = cmsContractActiveStatus;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        EcPmquotactionRequestEntity that = (EcPmquotactionRequestEntity) o;
        return id == that.id && Objects.equals(requestmessage, that.requestmessage) && Objects.equals(docid, that.docid) && Objects.equals(associationid, that.associationid) && Objects.equals(creationtime, that.creationtime) && Objects.equals(isneedvfssign, that.isneedvfssign) && Objects.equals(totalsignstatus, that.totalsignstatus) && Objects.equals(contractNum, that.contractNum) && Objects.equals(cmsContractActiveStatus, that.cmsContractActiveStatus);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id, requestmessage, docid, associationid, creationtime, isneedvfssign, totalsignstatus, contractNum, cmsContractActiveStatus);
    }
}
