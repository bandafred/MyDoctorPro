import * as React from "react";
import { Select } from "antd";
const { Option } = Select;

const SexSelect = (props: { setAction: Function }) => {
  const handleChange = (val: string) => {
    if (val === "isWoman") props.setAction(false);
    else props.setAction(true);
  };

  return (
    <>
      Пол: &nbsp;
      <Select
        defaultValue="isWoman"
        style={{ width: 120 }}
        onChange={(e) => handleChange(e)}
      >
        <Option value="isWoman">Женский</Option>
        <Option value="isMan">Мужской</Option>
      </Select>
    </>
  );
};
export default SexSelect;
