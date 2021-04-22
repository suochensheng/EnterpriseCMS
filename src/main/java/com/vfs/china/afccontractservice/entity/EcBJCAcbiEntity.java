package com.vfs.china.afccontractservice.entity;

import javax.persistence.*;
import java.sql.Timestamp;
import java.util.Objects;

@Entity
@Table(name = "ec_bjcacbi", schema = "csg_esign", catalog = "")
public class EcBJCAcbiEntity {
    private int id;
    private String docnum;
    private String responsecontent;
    private Timestamp creationtime;

    @Id
    @Column(name = "Id", nullable = false)
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    @Basic
    @Column(name = "Docnum", nullable = true)
    public String getDocnum() {
        return docnum;
    }

    public void setDocnum(String docnum) {
        this.docnum = docnum;
    }

    @Basic
    @Column(name = "Responsecontent", nullable = true)
    public String getResponsecontent() {
        return responsecontent;
    }

    public void setResponsecontent(String responsecontent) {
        this.responsecontent = responsecontent;
    }

    @Basic
    @Column(name = "Creationtime", nullable = true)
    public Timestamp getCreationtime() {
        return creationtime;
    }

    public void setCreationtime(Timestamp creationtime) {
        this.creationtime = creationtime;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        EcBJCAcbiEntity that = (EcBJCAcbiEntity) o;
        return id == that.id && Objects.equals(docnum, that.docnum) && Objects.equals(responsecontent, that.responsecontent) && Objects.equals(creationtime, that.creationtime);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id, docnum, responsecontent, creationtime);
    }
}
