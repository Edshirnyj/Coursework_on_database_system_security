CREATE OR REPLACE FUNCTION sample_function(input_param INTEGER)
RETURNS INTEGER AS $$
DECLARE
    result INTEGER;
BEGIN
    -- Sample calculation: multiply the input parameter by 2
    result := input_param * 2;
    RETURN result;
END;
$$ LANGUAGE plpgsql;