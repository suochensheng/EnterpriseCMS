package com.vfs.china.afccontractservice.entity;

import javax.persistence.*;
import java.sql.Timestamp;
import java.util.Objects;

@Entity
@Table(name = "ec_pmquotaction_response", schema = "csg_esign", catalog = "")
public class EcPmquotactionResponseEntity {
    private int id;
    private Integer pmquotactionRequestid;
    private String bjcaRequestmessage;
    private String bjcaResponsecode;
    private String bjcaResponsemessage;
    private String pmResponsecode;
    private String pmResponsemessage;
    private String associationid;
    private Timestamp creationtime;
    private String creditcode;
    private String contractnumber;
    private String bjcaContractactivestatuscode;
    private String bjcaDownloadpath;
    private String contractactivestatus;
    private String uncreditcode;
    private String quotationnum;

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
    @Column(name = "pmquotaction_requestid", nullable = true)
    public Integer getPmquotactionRequestid() {
        return pmquotactionRequestid;
    }

    public void setPmquotactionRequestid(Integer pmquotactionRequestid) {
        this.pmquotactionRequestid = pmquotactionRequestid;
    }

    @Basic
    @Column(name = "bjca_requestmessage", nullable = true, length = -1)
    public String getBjcaRequestmessage() {
        return bjcaRequestmessage;
    }

    public void setBjcaRequestmessage(String bjcaRequestmessage) {
        this.bjcaRequestmessage = bjcaRequestmessage;
    }

    @Basic
    @Column(name = "bjca_responsecode", nullable = true, length = 500)
    public String getBjcaResponsecode() {
        return bjcaResponsecode;
    }

    public void setBjcaResponsecode(String bjcaResponsecode) {
        this.bjcaResponsecode = bjcaResponsecode;
    }

    @Basic
    @Column(name = "bjca_responsemessage", nullable = true, length = 500)
    public String getBjcaResponsemessage() {
        return bjcaResponsemessage;
    }

    public void setBjcaResponsemessage(String bjcaResponsemessage) {
        this.bjcaResponsemessage = bjcaResponsemessage;
    }

    @Basic
    @Column(name = "pm_responsecode", nullable = true, length = 45)
    public String getPmResponsecode() {
        return pmResponsecode;
    }

    public void setPmResponsecode(String pmResponsecode) {
        this.pmResponsecode = pmResponsecode;
    }

    @Basic
    @Column(name = "pm_responsemessage", nullable = true, length = -1)
    public String getPmResponsemessage() {
        return pmResponsemessage;
    }

    public void setPmResponsemessage(String pmResponsemessage) {
        this.pmResponsemessage = pmResponsemessage;
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
    @Column(name = "creditcode", nullable = true, length = 100)
    public String getCreditcode() {
        return creditcode;
    }

    public void setCreditcode(String creditcode) {
        this.creditcode = creditcode;
    }

    @Basic
    @Column(name = "contractnumber", nullable = true, length = 100)
    public String getContractnumber() {
        return contractnumber;
    }

    public void setContractnumber(String contractnumber) {
        this.contractnumber = contractnumber;
    }


    @Basic
    @Column(name = "bjca_contractactivestatuscode", nullable = true, length = 100)
    public String getBjcaContractactivestatuscode() {
        return bjcaContractactivestatuscode;
    }

    public void setBjcaContractactivestatuscode(String bjcaContractactivestatuscode) {
        this.bjcaContractactivestatuscode = bjcaContractactivestatuscode;
    }

    @Basic
    @Column(name = "bjca_downloadpath", nullable = true, length = -1)
    public String getBjcaDownloadpath() {
        return bjcaDownloadpath;
    }

    public void setBjcaDownloadpath(String bjcaDownloadpath) {
        this.bjcaDownloadpath = bjcaDownloadpath;
    }

    @Basic
    @Column(name = "Contractactivestatus", nullable = true, length = 50)
    public String getContractactivestatus() {
        return contractactivestatus;
    }

    public void setContractactivestatus(String contractactivestatus) {
        this.contractactivestatus = contractactivestatus;
    }

    @Basic
    @Column(name = "uncreditcode", nullable = true, length = 250)
    public String getUncreditcode() {
        return uncreditcode;
    }

    public void setUncreditcode(String uncreditcode) {
        this.uncreditcode = uncreditcode;
    }


    @Basic
    @Column(name = "quotationnum", nullable = true, length = 250)
    public String getQuotationnum() {
        return quotationnum;
    }

    public void setQuotationnum(String quotationnum) {
        this.quotationnum = quotationnum;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        EcPmquotactionResponseEntity that = (EcPmquotactionResponseEntity) o;
        return id == that.id && Objects.equals(pmquotactionRequestid, that.pmquotactionRequestid) && Objects.equals(bjcaRequestmessage, that.bjcaRequestmessage) && Objects.equals(bjcaResponsecode, that.bjcaResponsecode) && Objects.equals(bjcaResponsemessage, that.bjcaResponsemessage) && Objects.equals(pmResponsecode, that.pmResponsecode) && Objects.equals(pmResponsemessage, that.pmResponsemessage) && Objects.equals(associationid, that.associationid) && Objects.equals(creationtime, that.creationtime) && Objects.equals(creditcode, that.creditcode) && Objects.equals(contractnumber, that.contractnumber)  && Objects.equals(bjcaContractactivestatuscode, that.bjcaContractactivestatuscode) && Objects.equals(bjcaDownloadpath, that.bjcaDownloadpath) && Objects.equals(contractactivestatus, that.contractactivestatus) && Objects.equals(uncreditcode, that.uncreditcode) && Objects.equals(quotationnum, that.quotationnum);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id, pmquotactionRequestid, bjcaRequestmessage, bjcaResponsecode, bjcaResponsemessage, pmResponsecode, pmResponsemessage, associationid, creationtime, creditcode, contractnumber, bjcaContractactivestatuscode, bjcaDownloadpath, contractactivestatus, uncreditcode, quotationnum);
    }
}
