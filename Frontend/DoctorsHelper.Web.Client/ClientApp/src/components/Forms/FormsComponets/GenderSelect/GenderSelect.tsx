import * as React from "react";
import { Select } from "antd";
const { Option } = Select;

const GenderSelect = (props:{
    isMan: boolean;
    setIsMan: Function;
}) => {

  return (
    <Select
      defaultValue={props.isMan? 'man': 'woman'}
      onChange={(e) => props.setIsMan((e as string) === "man")}
    >
      <Option value="woman">Женский пол</Option>
      <Option value="man">Мужской пол</Option>
    </Select>
  );
};
export default GenderSelect;
