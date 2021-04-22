package com.vfs.china.afccontractservice.service;

import com.vfs.china.afccontractservice.businessmodel.*;

public interface IPMCallBJCAService {
    PMResultDto sendPmQuotationToBjca(PMMessageInfoDto pmmessageInfo);
}
