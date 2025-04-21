CREATE OR REPLACE FUNCTION notify_data_change() 
RETURNS TRIGGER AS $$
BEGIN
    INSERT INTO data_changes_log (table_name, changed_at)
    VALUES (TG_TABLE_NAME, NOW());
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER sample_trigger
AFTER INSERT OR UPDATE OR DELETE ON your_table_name
FOR EACH ROW
EXECUTE FUNCTION notify_data_change();