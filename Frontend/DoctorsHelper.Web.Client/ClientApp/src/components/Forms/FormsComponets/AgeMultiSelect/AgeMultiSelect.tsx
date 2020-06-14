import * as React from "react";
import { Select } from "antd";
const { Option } = Select;

const AgeMultiSelect = (props: {
  setActionOld65: Function;
  setActionOld75: Function;
}) => {
  const handleChange = (val: string) => {
    if (val === "IsOld65") {
      props.setActionOld65(true);
      props.setActionOld75(false);
    }
    if (val === "IsOld75") {
      props.setActionOld65(false);
      props.setActionOld75(true);
    }
    if (val === "young") {
      props.setActionOld65(false);
      props.setActionOld75(false);
    }
  };

  return (
    <>
      Возраст: &nbsp;
      <Select
        defaultValue="young"
        style={{ width: 150 }}
        onChange={(e) => handleChange(e)}
      >
        <Option value="young">Младше 65 лет</Option>
        <Option value="IsOld65">65-75 года</Option>
        <Option value="IsOld75">Старше 74 лет</Option>
      </Select>
    </>
  );
};
export default AgeMultiSelect;
