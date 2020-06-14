import * as React from "react";
import { Select } from "antd";
import { ISelectNameValue } from "../../../../common/Interfaces";
const { Option } = Select;

const SelectedNameValue = (props: {
  setAction: Function;
  values: ISelectNameValue[];
  name: string;
  width: number;
}) => {
  return (
    <>
      {props.name}: &nbsp;
      <Select
        defaultValue={props.values[0].name}
        style={{ width: props.width }}
        onChange={(e, v) => props.setAction(e)}
      >
        {props.values.map((item) => (
          <Option value={item.value}>{item.name}</Option>
        ))}
      </Select>
    </>
  );
};
export default SelectedNameValue;
