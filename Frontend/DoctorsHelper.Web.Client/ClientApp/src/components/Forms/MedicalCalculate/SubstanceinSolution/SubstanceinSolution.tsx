import * as React from "react";
import {Row, Col} from "antd";
import {useState} from "react";
import TitleCalculatorArray from "../../FormsComponets/TitleCalculator/TitleCalculatorArray";
import ResultMedCalcilate from "../../FormsComponets/ResultMedCalcilate/ResultMedCalcilate";
import {IResult} from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import {
    SubstanceinSolutionResponse,
} from "../../../../apiClient/apiClient";
import InputInt from "../../FormsComponets/InputInt/InputInt";
import {SubstanceinSolutionResult} from "./SubstanceinSolutionAction";

const SubstanceinSolution = () => {
    let def: IResult<SubstanceinSolutionResponse> = {
        error: undefined,
        result: undefined,
    };

    let procentDefault = 1;
    let volumeDefault = 1;


    const [procent, serProcent] = useState(procentDefault);
    const [volume, setVolume] = useState(volumeDefault);

    const [result, setResult] = useState(def);
    const [isLoad, setIsLoad] = useState(false);

    const calcing = async () => {
        setIsLoad(true);
        setResult(await SubstanceinSolutionResult(procent, volume));
        setIsLoad(false);
    };

    return (
        <Row style={{marginBottom: 100}}>
            <Col span={24}>
                <TitleCalculatorArray
                    name={"Расчет содержания вещества в растворе (пересчет процентов в миллиграммы)"}
                    description={[
                        "Этот калькулятор позволяет пересчитать процентное содержание вещества в заданном объеме раствора в миллиграммы.",
                        "Расчеты исходят из того факта, что 1% любого вещества в среднем соответствует 10 мг вещества в растворе. Также известно, что 1 мг (миллиграмм) = 1000 мкг (микрограмм), а 1 г (грамм) = 1000 мг (миллиграмм).",
                    ]}
                />
            </Col>

            <Col xl={6} style={{marginTop: 10}}>
                <InputInt
                    default={procentDefault}
                    max={999}
                    min={1}
                    setAction={serProcent}
                    preName={"Процентное содержание"}
                    postName={"%"}
                />
            </Col>

            <Col xl={6} style={{marginTop: 10}}>
                <InputInt
                    default={volumeDefault}
                    max={999}
                    min={1}
                    setAction={setVolume}
                    preName={"Объем ампулы"}
                    postName={"мл."}
                />
            </Col>

            <Col xl={24}>
                <ButtonResult isLoad={isLoad} calcing={calcing}/>
            </Col>

            <Col xl={24}>
                <ResultMedCalcilate
                    result={result.result?.result}
                    error={result.error}
                />
            </Col>
        </Row>
    );
};
export default SubstanceinSolution;
