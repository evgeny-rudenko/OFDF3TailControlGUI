select 
cheque_date = date_cheque,
summ_cheque = summ,
kassa = cr.NAME_CASH_REGISTER,
kkm_cheque_number,
fp = fiscal_sign,
cheque_number=fiscal_document,
hash = ltrim( str (fiscal_document))+'|'+ ltrim (str(FISCAL_SIGN))
from cheque
inner join CASH_SESSION cs on cheque.ID_CASH_SESSION_GLOBAL = cs.ID_CASH_SESSION_GLOBAL 
inner join CASH_REGISTER cr on cr.ID_CASH_REGISTER = cs.ID_CASH_REGISTER 
where date_cheque between @MINDATE and @MAXDATE
order by date_cheque