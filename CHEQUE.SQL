select 
cheque_date = date_cheque,
summ_cheque = summ,
kassa = cr.NAME_CASH_REGISTER,
kkm_cheque_number,
fp = isnull ( fiscal_sign,'0'),
cheque_number=isnull ( fiscal_document,0),
hash = ltrim( str (isnull (fiscal_document,'0')))+'|'+ ltrim (str(isnull (FISCAL_SIGN, '0')))
from cheque
inner join CASH_SESSION cs on cheque.ID_CASH_SESSION_GLOBAL = cs.ID_CASH_SESSION_GLOBAL 
inner join CASH_REGISTER cr on cr.ID_CASH_REGISTER = cs.ID_CASH_REGISTER 
where date_cheque between @MINDATE and @MAXDATE
order by date_cheque