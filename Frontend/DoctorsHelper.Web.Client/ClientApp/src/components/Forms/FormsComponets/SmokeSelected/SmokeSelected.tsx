import * as React from "react";
import { Select } from "antd";
const { Option } = Select;

const SmokeSelected = (props: { setAction: Function }) => {
  const handleChange = (val: string) => {
    if (val === "isNosmoker") props.setAction(false);
    else props.setAction(true);
  };

  return (
    <>
      Курение: &nbsp;
      <Select
        defaultValue="isNosmoker"
        style={{ width: 80 }}
        onChange={(e) => handleChange(e)}
      >
        <Option value="isNosmoker">Нет</Option>
        <Option value="isSmorer">Да</Option>
      </Select>
    </>
  );
};
export default SmokeSelected;
