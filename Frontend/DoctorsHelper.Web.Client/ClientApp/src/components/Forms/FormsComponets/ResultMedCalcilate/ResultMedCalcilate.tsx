import * as React from "react";
import { Divider, Typography } from "antd";
import { IGeneralResult, IErrors } from "../../../../common/Interfaces";
const { Paragraph } = Typography;

const ResultMedCalcilate = (props: {
  result?: string | string[] | undefined | IGeneralResult[];
  error?: IErrors | undefined;
  level?: string | undefined;
  index?: number | undefined;
}) => {
  if (Array.isArray(props.result))
    return (
      <>
        <Divider>Результат</Divider>
        <Typography>
          {(props.result as IGeneralResult[]).map((item) => (
            <Paragraph strong>{item}</Paragraph>
          ))}
        </Typography>
      </>
    );

  if (props.result !== undefined)
    return (
      <>
        <Divider>Результат</Divider>
        {props.index != undefined ? (
          <Typography>
            <Paragraph strong>Индекс = {props.index}</Paragraph>
          </Typography>
        ) : null}
        <Typography>
          <Paragraph strong>{props.result}</Paragraph>
        </Typography>
        {props.level != undefined ? (
          <Typography>
            <Paragraph strong>{props.level}</Paragraph>
          </Typography>
        ) : null}
      </>
    );
  else if (props.error != undefined)
    return (
      <>
        <Divider style={{ color: "red" }}>Ошибка!!!</Divider>
        <Typography>
          {props.error.errors.map((item) => (
            <Paragraph strong key={item}>
              {item}
            </Paragraph>
          ))}
        </Typography>
      </>
    );
  else return null;
};

export default ResultMedCalcilate;
