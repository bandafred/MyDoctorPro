import * as React from "react";
import { Divider, Typography } from "antd";
import styles from "./TitleCalculator.module.css";

const { Title, Paragraph } = Typography;

const TitleCalculator = (props: { name: string; description: string }) => {
  return (
    <>
      <Typography>
        <Title level={1} className={styles.title}>
          {props.name}
        </Title>
        <Paragraph className={styles.text}>{props.description}</Paragraph>
      </Typography>
      <Divider>Расчет</Divider>
    </>
  );
};
export default TitleCalculator;