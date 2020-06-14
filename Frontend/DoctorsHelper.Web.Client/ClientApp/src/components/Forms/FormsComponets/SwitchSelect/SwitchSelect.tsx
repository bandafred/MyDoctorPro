import * as React from "react";
import styles from "./SwitchSelect.module.css";
import { Switch } from "antd";
import { CloseOutlined, CheckOutlined } from "@ant-design/icons";
import { useState } from "react";

const SwitchSelect = (props: { text: string; setAction: Function }) => {
  const [val, setVal] = useState(false);

  const SetVal = (value: boolean) => {
    setVal(value);
    props.setAction(value);
  };

  return (
    <>
      <Switch
        style={{ margin: 10 }}
        checkedChildren={<CheckOutlined />}
        unCheckedChildren={<CloseOutlined />}
        checked={val}
        onChange={(e) => SetVal(e)}
        title={props.text}
      />
      <span  className={styles.text} onClick={() => SetVal(!val)}>
        {props.text}
      </span>
    </>
  );
};
export default SwitchSelect;
