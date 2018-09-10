import { Skill } from "./skill";
import { JobLocation } from "./jobLocation";

export interface JobAd {
    id: number;
    name: string;
    location: JobLocation;
    skill: Skill;
    posNeeded: number;
    description: string;
    requirments: string;
    payRate: number;
    chargeRate: number;
    totalCharge: number;
    startDate: Date;
    endDate: Date;
    duration: number;
}