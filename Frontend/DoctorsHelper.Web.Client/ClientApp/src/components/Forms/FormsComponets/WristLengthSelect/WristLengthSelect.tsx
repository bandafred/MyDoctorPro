import * as React from "react";
import { InputNumber } from "antd";

const WristLengthSelect = (props: {
  min: number;
  max: number;
  default: number;
  setWristLength: Function;
}) => {
  return (
    <>
      Объем запястья в самом тонком месте в сантиметрах: &nbsp;
      <InputNumber
        min={props.min}
        max={props.max}
        defaultValue={props.default}
        onChange={(e) => props.setWristLength(e)}
      /> см.
    </>
  );
};
export default WristLengthSelect;
