CREATE OR REPLACE PROCEDURE sample_procedure(IN param1 INTEGER, OUT result INTEGER)
LANGUAGE plpgsql
AS $$
BEGIN
    -- Sample logic: Calculate the square of the input parameter
    result := param1 * param1;
END;
$$;