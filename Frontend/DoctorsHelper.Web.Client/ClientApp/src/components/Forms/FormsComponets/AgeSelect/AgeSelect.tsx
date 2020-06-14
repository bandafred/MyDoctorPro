import * as React from "react";
import { InputNumber } from "antd";

const AgeSelect = (props: {
  min: number;
  max: number;
  default: number;
  setAction: Function;
}) => {
  return (
    <>
      Возраст: &nbsp;
      <InputNumber
        min={props.min}
        max={props.max}
        defaultValue={props.default}
        onChange={(e) => props.setAction(e)}
      />
    </>
  );
};
export default AgeSelect;
