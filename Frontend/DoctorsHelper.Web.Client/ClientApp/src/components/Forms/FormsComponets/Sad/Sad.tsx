import * as React from "react";
import { InputNumber } from "antd";

const Sad = (props: {
  min: number;
  max: number;
  default: number;
  setAction: Function;
}) => {
  return (
    <>
      Верхнее АД: &nbsp;
      <InputNumber
        min={props.min}
        max={props.max}
        defaultValue={props.default}
        onChange={(e) => props.setAction(e)}
      /> мм.рт.ст.
    </>
  );
};
export default Sad;
