import graphqlServer from './server';
import { PortfolioSchema } from './portfolioSchema.js';
graphqlServer(PortfolioSchema,8080);