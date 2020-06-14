import * as React from "react";
import { InputNumber } from "antd";

const InputInt = (props: {
  min: number;
  max: number;
  default: number;
  setAction: Function;
  preName: string;
  postName?: string;
}) => {
  return (
    <>
      {props.preName}: &nbsp;
      <InputNumber
        min={props.min}
        max={props.max}
        defaultValue={props.default}
        onChange={(e) => props.setAction(e)}
      /> {props.postName}
    </>
  );
};
export default InputInt;
