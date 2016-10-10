SELECT * FROM CargoSet As cs INNER JOIN UserCargo AS uc
ON cs.Id=uc.Cargo_Id
 INNER JOIN UserSet AS us
 ON uc.User_Id=us.Id
WHERE us.Id=1