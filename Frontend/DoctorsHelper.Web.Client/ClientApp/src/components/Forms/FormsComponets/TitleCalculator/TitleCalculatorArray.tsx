import * as React from "react";
import { Divider, Typography } from "antd";
import styles from "./TitleCalculator.module.css";

const { Title, Paragraph } = Typography;

const TitleCalculatorArray = (props: {
  name: string;
  description: string[];
}) => {
  return (
    <>
      <Typography>
        <Title level={1} className={styles.title}>
          {props.name}
        </Title>
        {props.description.map((item) => (
          <Paragraph className={styles.text}>{item}</Paragraph>
        ))}
      </Typography>
      <Divider>Расчет</Divider>
    </>
  );
};
export default TitleCalculatorArray;
