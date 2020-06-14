import * as React from "react";
import { Divider, Typography } from "antd";
import { IErrors } from "../../../../common/Interfaces";
import { AntihypertensiveTherapyResponse } from "../../../../apiClient/apiClient";
const { Paragraph } = Typography;

const ResultAntiHypertensionTherapy = (props: {
  result?: AntihypertensiveTherapyResponse;
  error?: IErrors | undefined;
}) => {
  if (props.result !== undefined)
    return (
      <>
        <Divider>Результат</Divider>
        {props.result.recommended?.length ? (
          <Typography>
            <p><b>Рекомендовано</b></p>
            {props.result.recommended.map((item) => (
              <Paragraph strong>{item}</Paragraph>
            ))}
          </Typography>
        ) : null
        }
         {props.result.notRecommended?.length ? (
          <Typography>
            <p><b>Относительно противопоказаны</b></p>
            {props.result.notRecommended.map((item) => (
              <Paragraph strong>{item}</Paragraph>
            ))}
          </Typography>
        ) : null
        }
         {props.result.contraindicated?.length ? (
          <Typography>
            <p><b>Абсолютно противопоказаны</b></p>
            {props.result.contraindicated.map((item) => (
              <Paragraph strong>{item}</Paragraph>
            ))}
          </Typography>
        ) : null
        }
      </>
    );
  else if (props.error !== undefined)
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

export default ResultAntiHypertensionTherapy;
