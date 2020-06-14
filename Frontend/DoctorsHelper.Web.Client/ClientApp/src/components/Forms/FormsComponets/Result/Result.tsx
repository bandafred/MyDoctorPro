import * as React from "react";
import { Divider, Typography } from "antd";
import { IGeneralResult, IErrors } from "../../../../common/Interfaces";
const { Paragraph } = Typography;

const Result = (props: {
  result?: string | undefined | IGeneralResult[];
  error?: IErrors | undefined;
}) => {
  if (Array.isArray(props.result))
    return (
      <>
        <Divider>Результат</Divider>
        <Typography>
          {(props.result as IGeneralResult[]).map((item) => (
            <Paragraph strong>
              {item.nameCalculator}: {item.result}
            </Paragraph>
          ))}
        </Typography>

      </>
    );

  if (props.result !== undefined)
    return (
      <>
        <Divider>Результат</Divider>
        <Typography>
          <Paragraph strong>{props.result}</Paragraph>
        </Typography>
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

export default Result;
