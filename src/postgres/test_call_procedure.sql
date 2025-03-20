CALL AddNewClient('Иван', 'Иванович', 'Иванов',
    pgp_sym_encrypt('1234567890', 'test-key'),
    pgp_sym_encrypt('ivan2329@example.test', 'test-key'),
    pgp_sym_encrypt('3892', 'test-key'),
    pgp_sym_encrypt('480923', 'test-key')
);