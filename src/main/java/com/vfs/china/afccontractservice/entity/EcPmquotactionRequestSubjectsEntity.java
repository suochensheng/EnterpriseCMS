package com.vfs.china.afccontractservice.entity;

import javax.persistence.*;
import java.util.Objects;

@Entity
@Table(name = "ec_pmquotaction_request_subjects", schema = "csg_esign", catalog = "")
public class EcPmquotactionRequestSubjectsEntity {
    private int id;
    private Integer requestId;
    private String associationid;
    private String signingRole;
    private String name;
    private String status;
    private String type;
    private String creditCode;

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "Id", nullable = false)
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    @Basic
    @Column(name = "requestid", nullable = true)
    public Integer getRequestId() {
        return requestId;
    }

    public void setRequestId(Integer requestId) {
        this.requestId = requestId;
    }

    @Basic
    @Column(name = "associationid", nullable = true, length = 250)
    public String getAssociationid() {
        return associationid;
    }

    public void setAssociationid(String associationid) {
        this.associationid = associationid;
    }

    @Basic
    @Column(name = "signingrole", nullable = true, length = 250)
    public String getSigningRole() {
        return signingRole;
    }

    public void setSigningRole(String signingRole) {
        this.signingRole = signingRole;
    }

    @Basic
    @Column(name = "name", nullable = true, length = 250)
    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Basic
    @Column(name = "status", nullable = true, length = 50)
    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        EcPmquotactionRequestSubjectsEntity that = (EcPmquotactionRequestSubjectsEntity) o;
        return id == that.id && Objects.equals(requestId, that.requestId) && Objects.equals(associationid, that.associationid) && Objects.equals(signingRole, that.signingRole) && Objects.equals(name, that.name) && Objects.equals(status, that.status);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id, requestId, associationid, signingRole, name, status);
    }

    @Basic
    @Column(name = "type", nullable = true, length = 50)
    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    @Basic
    @Column(name = "creditcode", nullable = true, length = 300)
    public String getCreditCode() {
        return creditCode;
    }

    public void setCreditCode(String creditCode) {
        this.creditCode = creditCode;
    }
}
