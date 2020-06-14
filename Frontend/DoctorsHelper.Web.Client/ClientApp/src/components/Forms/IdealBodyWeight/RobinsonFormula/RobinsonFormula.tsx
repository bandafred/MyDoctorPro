import * as React from "react";
import {Row, Col} from "antd";
import styles from "./RobinsonFormula.module.css";
import {useState} from "react";
import GenderSelect from "../../FormsComponets/GenderSelect/GenderSelect";
import TitleCalculator from "../../FormsComponets/TitleCalculator/TitleCalculator";
import {RobinsonFormulaResponse} from "../../../../apiClient/apiClient";
import Result from "../../FormsComponets/Result/Result";
import HeightSelect from "../../FormsComponets/Height/HeightSelect";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import {IResult} from "../../../../common/Interfaces";
import {RobinsonFormulaCalculate} from "./Actions/RobinsonFormulaCalculate";

const RobinsonFormula = () => {
    let heightDefault = 141;

    let def: IResult<RobinsonFormulaResponse> = {
        error: undefined,
        result: undefined,
    };

    const [isMan, setIsMan] = useState(false);
    const [height, setHeight] = useState(heightDefault);
    const [result, setResult] = useState(def);
    const [isLoad, setIsLoad] = useState(false);

    const calcing = async () => {
        setIsLoad(true);
        setResult(await RobinsonFormulaCalculate(height, isMan));
        setIsLoad(false);
    };

    return (
        <Row className={styles.wrap}>
            <Col span={24}>
                <TitleCalculator
                    name={"Формула Робинсона"}
                    description={
                        "Улучшенная формула Девина появилась в 1983 году. Робинсон внес изменения в формулу Девина, так как старая формула не опиралась ни на какие статистические данные и основывалась только на математических методах. Но новая формула не совсем корректно определяет вес для мужчин."
                    }
                />
            </Col>

            <Col xl={3} className={styles.genderSelect}>
                <GenderSelect isMan={isMan} setIsMan={setIsMan}/>
            </Col>

            <Col xl={11}>
                <HeightSelect
                    setAction={setHeight}
                    default={heightDefault}
                    min={141}
                    max={220}
                />
            </Col>

            <Col xl={24}>
                <ButtonResult isLoad={isLoad} calcing={calcing}/>
            </Col>

            <Col xl={24}>
                <Result result={result.result?.result} error={result.error}/>
            </Col>
        </Row>
    );
};
export default RobinsonFormula;
