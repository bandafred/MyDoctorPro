import * as React from "react";
import { Divider, Typography } from "antd";
import styles from "./DictionaryPageTitle.module.css";

const { Title, Paragraph } = Typography;

const DictionaryPageTitleArray = (props: {
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
    </>
  );
};
export default DictionaryPageTitleArray;
